import store from "../../store";
import "core-js/stable";
import "regenerator-runtime/runtime";

class SiteService {
    constructor() {
        this.backendAPI = store.getState().backendAPI;
        this.backend1cAPI = store.getState().backend1cAPI;
    }

    async WaitForToken() {
        return new Promise(resolve => {
            let timerId = setInterval(() => {
                if (store.getState().CurrentUser.tokenUpdated) {
                    resolve();
                    clearInterval(timerId);
                }
            }, 50);
        });
    }

    async RequestToAPI(method, url, data = null ) {
        let AuthHeader = {'Authorization': 'Bearer ' + store.getState().CurrentUser.accessToken};
        let fullUrl = this.backendAPI.url + url;
        let response;
        try {
            if (data != null) {
                response = await this.backendAPI.app[method](fullUrl, data, {headers: AuthHeader});
            } else {
                response = await this.backendAPI.app[method](fullUrl, {headers: AuthHeader});
            }
        } catch (e) {
            console.log("Can't " + method + " :" + data);
        }
        if (response.status === 200) {
            return response;
        }
        throw new Error('Service unavailable');
    }

    async GetDevices(id = 0) {
        await this.WaitForToken();
        let url = id > 0 ? this.backendAPI.devices + '/' + id : this.backendAPI.devices;
        const result = await this.RequestToAPI("get", url);
        return result.data.records;
    }
    async PutDevice(device){
        let url = this.backendAPI.devices;
        const data = JSON.stringify(device);
        const result = await this.RequestToAPI("put", url, data);
        return result;
    }

    async AddDevice(device) {
        let url = this.backendAPI.devices;
        const data = JSON.stringify(device);
        const result = await this.RequestToAPI("post", url, data);
        return result;
    }

    async DeleteDevice(id){
        let url = this.backendAPI.devices+ '/'+id;
        const result = await this.RequestToAPI("delete", url);
        return result;
    }

    async GetJWT() {
        let url = this.backendAPI.url + this.backendAPI.user;
        let response;
        try {
            response = await this.backendAPI.app.get(url);
        } catch (e) {
            console.log("Can't get users");
        }
        if (response.status === 200) {
            const result = response.data;
            return result;
        }
        throw new Error('Service unavailable');
    }

    async TestSoap(){
        const data = '<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope" xmlns:mob="http://www.mobile.itilium.org">\n' +
            '   <soap:Header/>\n' +
            '   <soap:Body>\n' +
            '      <mob:GetDataOfUser/>\n' +
            '   </soap:Body>\n' +
            '</soap:Envelope>';

        let response;
        try {
            response = await this.backend1cAPI.app.post(this.backend1cAPI.url,data);
        } catch (e) {
            console.log("Can't get users");
        }
        if (response.status === 200) {
            const result = response.data;
            return result;
        }
        throw new Error('Service unavailable');
    }
}

export default SiteService;
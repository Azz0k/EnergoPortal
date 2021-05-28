import store from "../../store";
import "core-js/stable";
import "regenerator-runtime/runtime";

class SiteService {
    constructor() {
        this.backendAPI = store.getState().backendAPI;
    }

    async WaitForToken(){
        return new Promise(resolve => {
            let timerId=setInterval(()=>{
                if (store.getState().CurrentUser.tokenUpdated){
                    resolve();
                    clearInterval(timerId);
                }
            },50);
        });
    }


    async GetDevices(id= 0) {
        await this.WaitForToken();
        let AuthHeader = { 'Authorization': 'Bearer ' + store.getState().CurrentUser.accessToken};
        let url = this.backendAPI.url+this.backendAPI.devices;
        if (id>0){
            url = url + '/'+id;
        }
        let response;
        try {
            response = await this.backendAPI.app.get(url,{ headers: AuthHeader });
        }
        catch (e){
            console.log("Can't get devices");
        }
        if (response.status === 200) {
            const  result  = response.data.records;
            return result;
        }
        throw new Error('Service unavailable');
    };

    async GetJWT(){
        let url = this.backendAPI.url+this.backendAPI.user;
        let response;
        try {
            response = await this.backendAPI.app.get(url);
        }
        catch (e){
            console.log("Can't get users");
        }
        if (response.status === 200) {
            const  result  = response.data;
            return result;
        }
        throw new Error('Service unavailable');
    };

    async PutDevice(device){
        let AuthHeader = { 'Authorization': 'Bearer ' + store.getState().CurrentUser.accessToken};
        let url = this.backendAPI.url+this.backendAPI.devices;
        const data = JSON.stringify(device);
        let response;
        try {
            response = await this.backendAPI.app.put(url,data,{ headers: AuthHeader });
        }
        catch (e){
            console.log("Can't update device id:"+device.deviceId);
        }
        if (response.status === 200) {
            return response;
        }
        throw new Error('Service unavailable');
    }
    async AddDevice(device){
        let AuthHeader = { 'Authorization': 'Bearer ' + store.getState().CurrentUser.accessToken};
        let url = this.backendAPI.url+this.backendAPI.devices;
        const data = JSON.stringify(device);
        let response;
        try {
            response = await this.backendAPI.app.post(url,data,{ headers: AuthHeader });
        }
        catch (e){
            console.log("Can't add devices");
        }
        if (response.status === 200) {
            return response;
        }
        throw new Error('Service unavailable');
    }
    async DeleteDevice(id){
        let AuthHeader = { 'Authorization': 'Bearer ' + store.getState().CurrentUser.accessToken};
        let url = this.backendAPI.url+this.backendAPI.devices+ '/'+id;
        let response;
        try {
            response = await this.backendAPI.app.delete(url,{ headers: AuthHeader });
        }
        catch (e){
            console.log("Can't delete device id:"+id);
        }
        if (response.status === 200) {
            return response;
        }
        throw new Error('Service unavailable');
    }

}



export default SiteService;
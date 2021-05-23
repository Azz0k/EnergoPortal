import store from "../../store";
import "core-js/stable";
import "regenerator-runtime/runtime";

class SiteService {

    async GetDevices() {
        const {backendAPI} = store.getState();
        const url = backendAPI.url+backendAPI.devices;
        let response;
        try {
            response = await backendAPI.app.get(url);
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



}

export default SiteService;
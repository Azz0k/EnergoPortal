import React, { useState, useEffect } from 'react';
import { connect } from "react-redux";
import {WithSiteService} from "../components/hoc";
import Modal, {ModalHeader, ModalFooter, ModalBody} from "../components/Modal";
import {InputSelectField,InputCheckBox,InputTextField, DeviceIcon} from "../components/FormElements";

const actionsMenu = ["Редактировать", "Переместить", "Добавить", "Удалить"];
const EmptyDevice = {color:"",
    deviceId: 0,
    deviceName: "",
    firstName: "",
    ipAddress: "",
    isEnabled: 0,
    isInUse: 0,
    lastName: "",
    levelId: 0,
    location: "",
    loginName: "",
    macAddress: "",
    mailAddress: "",
    memo: "",
    middleName: "",
    pbxPortNumber: "",
    phoneId: "",
    phoneNumber: "",
    phoneSocketNumber: "",
    posX: 0,
    posY: 0,
    socketNumber: "",
    switchName: "",
    switchPort: "",
    type: ""};

const TypesToColors ={"Компьютер":"Red", "Принтер":"Green", "WiFi":"Blue", "Другое":"Yellow", "Камера":"Violet", "Регистратор":"Black"};
const DeviceTextFieldsWithPlaceholders = {
        "socketNumber":"Номер розетки",
        "switchName":"Название свича",
        "switchPort":"Номер порта на свиче",
        "ipAddress":"IP адрес",
        "macAddress":"МАС адрес",
        "deviceName":"Название",
        "phoneSocketNumber":"Номер розетки телефона",
        "pbxPortNumber":"Порт АТС",
        "phoneNumber":"Номер телефона",
        "phoneId":"Инвентарный номер телефона",
        "firstName":"Фамилия",
        "lastName":"Имя",
        "middleName":"Отчество",
        "loginName":"Имя пользователя",
        "mailAddress":"Адрес электронной почты",
        "location":"Кабинет",
        "memo":"Заметки"
};
const DeviceTextFields = Object.keys(DeviceTextFieldsWithPlaceholders);

const DeviceWindow = ({device, isOpen, closeClick,saveClick, change, readonly}) =>{
    const InputTextFields = Object
        .entries(device)
        .filter(([key,value])=>DeviceTextFields.includes(key))
        .map(([key,value])=>
            <InputTextField
                onchange={change}
                name={key}
                value={value}
                key={key}
                placeholder={DeviceTextFieldsWithPlaceholders[key]}
                readonly={readonly}
            />);
    return(
        <Modal isOpen={isOpen}>
            <ModalHeader>
                <h4>{device.deviceName}</h4>
            </ModalHeader>
            <ModalBody>
                <div className="row">
                    {InputTextFields}
                    <InputCheckBox
                        onchange={change}
                        name="isInUse"
                        value={device.isInUse}
                        key="isInUse"
                        placeholder="В использовании"
                        readonly={readonly}
                    />
                    <InputSelectField
                        onchange={change}
                        name="type"
                        value={device.type}
                        key="type"
                        readonly={readonly}
                    />
                </div>
            </ModalBody>
            <ModalFooter>
                <button
                    type="button"
                    className="btn btn-secondary"
                    onClick={closeClick}
                >
                    Close
                </button>
                <button
                    type="button"
                    className="btn btn-primary"
                    onClick={saveClick}
                >
                    Сохранить
                </button>
            </ModalFooter>
        </Modal>
    );
};

//TODO: перемещение
//TODO: добавление и удаление
const FloorsPlan = ({ SiteService, FloorsImages, CurrentUser }) => {
    const [activeImage, setActiveImage] = useState(0); //текущий этаж
    const [activeAction, setActiveAction] = useState(0);
    const [isUpdated, setIsUpdated] = useState(false); //для обновления всех координат устройств установить в false
    const [devices, setDevices] = useState([]);//координаты, цвета и т.д всех устройств
    const [isOpenModal, setIsOpenModal] = useState(false); //модальное окно открыто ли
    const [currentDevice, setCurrentDevice] = useState(EmptyDevice); //выбранное устройство
    const [isChanged, setIsChanged] = useState(false); //были ли изменения, надо ли записывать.
    const [dragStarted, setDragStarted] = useState(false);
    const [deltaPosition, setDeltaPosition] = useState({x:0, y:0});
    useEffect(() => {
        if (!isUpdated) {
            SiteService.GetDevices().then(result=>{
                setDevices(result);
                setIsUpdated(true);
            });
        }
    });

    const handleMouseClick = (event) =>{
        if (activeAction===2 && CurrentUser.role>3){
            const newDevice = {...EmptyDevice,posX:event.clientX-5,posY:event.clientY-115,isEnabled: 1, isInUse: 1, levelId: activeImage+1};
            setCurrentDevice(newDevice);
            setIsChanged(false);
            setIsOpenModal(!isOpenModal);
        }
    };
    const DeviceOnClick = (id) =>{
        if (activeAction===0){
            setIsChanged(false);
            setIsOpenModal(!isOpenModal);
            SiteService.GetDevices(id).then(result => {
                setCurrentDevice(result[0]);
            });
        }

        if (activeAction===3 && CurrentUser.role>4){
            SiteService.DeleteDevice(id).then(r=> setIsUpdated(false));
        }

    };

    const handleMouseDown = (event, device) =>{
        setIsChanged(false);
        if (activeAction===1 && CurrentUser.role>2){
            SiteService.GetDevices(device.deviceId).then(result => {
                setCurrentDevice(result[0]);
                setDragStarted(true);
            });
            setDeltaPosition({x:(event.clientX-device.posX),y:(event.clientY-device.posY)});
        }
    };

    const handleMouseUp = (event,device) =>{
        if (activeAction===1){
            setDragStarted(false);
            if (isChanged){
                SiteService.PutDevice(currentDevice).then(r=>setIsUpdated(false));
                setIsChanged(false);
            }
        }
    };

    const handleMouseMove = (event) =>{
        if (activeAction ===1 && dragStarted){
            setIsChanged(true);
            const newDevice = {...currentDevice,posX: (event.clientX-deltaPosition.x),posY: (event.clientY-deltaPosition.y)};
            setCurrentDevice(newDevice);
            const newDevices = devices.map(el=>el.deviceId===newDevice.deviceId?newDevice:el);
            setDevices(newDevices);
        }
    };

    const handleChange = (event) => {
        const value = event.target.type === 'checkbox' ? +event.target.checked : event.target.value;
        setIsChanged(true);
        let newDevice={
            ...currentDevice,
            [event.target.name]:value,
        };
        let color;
        if (event.target.name==="type") {
            color = TypesToColors[event.target.value];
            newDevice = {...newDevice, color}
        }
        setCurrentDevice(newDevice);
    };

    const  handleSaveClick =()=>{
        setIsOpenModal(!isOpenModal);
        if (isChanged ){
            if (activeAction===0){
                SiteService.PutDevice(currentDevice).then(r=>setIsUpdated(false));
            }
            else {
                console.log(currentDevice);
                SiteService.AddDevice(currentDevice).then(r=>setIsUpdated(false));
            }
        }
        setIsChanged(false);
    };

    const floorsTab = FloorsImages.map((element, index) => {
        const className = index === activeImage ? "FloorTabItem nav-link active" : "FloorTabItem nav-link";

        return (
            <li className="nav-item" onClick={() => setActiveImage(index)} key={element.id}>
                <span className={className} > {element.name}</span>
            </li>
        );
    });

    const actionTabs = actionsMenu.map((element,index) =>{
        let className = index === activeAction ? "FloorTabItem nav-link active" : "FloorTabItem nav-link";
        className += (index+1) < CurrentUser.role? "":" disabled";
        return(
            <li className="nav-item" onClick={() =>(index+1) < CurrentUser.role?setActiveAction(index):console.log("Deny") } key={index} >
                <span className={className} > {element}</span>
            </li>
        );
    });

    const Devices = devices.filter(e=>(e.isEnabled && e.levelId===(activeImage+1))).map(e =>{
        return(
            <DeviceIcon
                id={e.deviceId}
                posX={e.posX} posY={e.posY}
                color ={e.isInUse===1?e.color:"grey"}
                key={e.deviceId}
                click={()=> DeviceOnClick(e.deviceId)}
                mouseDown={(event)=>handleMouseDown(event,e)}
                mouseUp={(event)=>handleMouseUp(event,e)}

            />);
    })

    return (
        <div className="unselectable">
            <ul className="nav nav-tabs FloorTabs justify-content-center">
                {floorsTab}
            </ul>
            <ul className="nav nav-pills FloorTabs justify-content-center">
                {actionTabs}
            </ul>
            <div className="imageContainer">
                <svg
                    className="DeviceSvg"
                    xmlns="http://www.w3.org/2000/svg"
                    width="1700" height="800"
                    onMouseMove={handleMouseMove}
                    onClick={handleMouseClick}
                >
                    {Devices}
                </svg>
                <img src={FloorsImages[activeImage].href} className="floorImg" alt="..." />
            </div>
            <DeviceWindow
                device={currentDevice}
                isOpen={isOpenModal}
                closeClick={()=> setIsOpenModal(!isOpenModal)}
                saveClick={() => handleSaveClick()}
                change={(event) => handleChange(event)}
                readonly={CurrentUser.role===1}
            />
        </div> 
        );
};

const mapStateToPropsFloorsPlan = ({ FloorsImages, CurrentUser }) => {
    return { FloorsImages,CurrentUser };
};

export default WithSiteService(connect(mapStateToPropsFloorsPlan)(FloorsPlan));
import React, { useState, useEffect } from 'react';
import { connect } from "react-redux";
import {WithSiteService} from "../components/hoc";
import Modal, {ModalHeader, ModalFooter, ModalBody} from "../components/Modal";
import {InputSelectField,InputCheckBox,InputTextField, DeviceIcon} from "../components/FormElements";
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
    const [isUpdated, setIsUpdated] = useState(false); //для обновления всех координат устройств установить в false
    const [devices, setDevices] = useState([]);//координаты, цвета и т.д всех устройств
    const [isOpenModal, setIsOpenModal] = useState(false); //модальное окно открыто ли
    const [currentDevice, setCurrentDevice] = useState(EmptyDevice); //выбранное устройство
    const [isChanged, setIsChanged] = useState(false); //были ли изменения, надо ли записывать.
    useEffect(() => {
        if (!isUpdated) {
            SiteService.GetDevices().then(result=>{
                setDevices(result);
                setIsUpdated(true);
            });
        }
    });
    const DeviceOnClick = (id) =>{
        setCurrentDevice(EmptyDevice);
        setIsChanged(false);
        setIsOpenModal(!isOpenModal);
        SiteService.GetDevices(id).then(result => {
            setCurrentDevice(result[0]);
        });

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
        if (isChanged){
            SiteService.PutDevice(currentDevice).then(r=>setIsUpdated(false));
        }
        setIsOpenModal(!isOpenModal);
    };

    const floortab = FloorsImages.map((element, index) => {
        const className = index === activeImage ? "FloorTabItem nav-link active" : "FloorTabItem nav-link";

        return (
            <li className="nav-item" onClick={() => setActiveImage(index)} key={element.id}>
                <span className={className} > {element.name}</span>
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

            />);
    })


    return (
        <div className="unselectable">
            <ul className="nav nav-tabs FloorTabs justify-content-center">
                {floortab}
            </ul>
            <div className="imageContainer">
                <svg className="DeviceSvg" xmlns="http://www.w3.org/2000/svg" width="1600" height="800">
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
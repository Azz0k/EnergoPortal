import React, { useState, useEffect } from 'react';
import { connect } from "react-redux";
import {WithSiteService} from "../components/hoc";
import Modal, {ModalHeader, ModalFooter, ModalBody} from "../components/Modal";

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

const InputField = ({ value, onchange, name, placeholder="", readonly = false}) =>{
    return(
        <div className="input-group mb-3 DeviceInput col-sm">
            <input
                type="text"
                className="form-control "
                placeholder={placeholder}
                name={name}
                value={value}
                readOnly={readonly}
                onChange={onchange}
            />
        </div>
    );
};

const DeviceWindow = ({device, isOpen, closeClick,saveClick, change, readonly}) =>{

    const InputFields = Object
        .entries(device)
        .filter(([key,value])=>DeviceTextFields.includes(key))
        .map(([key,value])=>
            <InputField
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
                    {InputFields}
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

const DeviceIcon = ({id, posX, posY, color, click  }) => {
    return (
            <rect
                x={posX} y={posY}
                width="19" height="19"
                fill={color}
                stroke="black"
                strokeWidth="2"
                onClick={click}
            />
    );
};


const FloorsPlan = ({ SiteService, FloorsImages, CurrentUser }) => {
    const [activeImage, setActiveImage] = useState(0); //текущий этаж
    const [isUpdated, setIsUpdated] = useState(false); //для обновления всех координат устройств установить в false
    const [devices, setDevices] = useState([]);//координаты, цвета и т.д всех устройств
    const [isOpenModal, setIsOpenModal] = useState(false); //модальное окно открыто ли
    const [currentDevice, setCurrentDevice] = useState({}); //выбранное устройство
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
        setIsChanged(false);
        setIsOpenModal(!isOpenModal);
        SiteService.GetDevices(id).then(result => {
            setCurrentDevice(result[0]);
        });

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

    const handleChange = (event) => {
        setIsChanged(true);
        setCurrentDevice({
            ...currentDevice,
            [event.target.name]:event.target.value,
        });
    };
    const  handleSaveClick =()=>{
        if (isChanged){
            SiteService.PutDevice(currentDevice).then(r => console.log(r));
        }
        setIsOpenModal(!isOpenModal);
    };

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
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

const DeviceWindow = ({device, isOpen, click, change}) =>{

    const InputFields = Object.entries(device).filter(([key,value])=>DeviceTextFields.includes(key)).map(([key,value])=> <InputField onchange={change} name={key} value={value} key={key} placeholder={DeviceTextFieldsWithPlaceholders[key]}/>);
    return(
        <Modal isOpen={isOpen}>
            <ModalHeader>
                <h3>This is modal header</h3>

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
                    onClick={click}
                >
                    Close
                </button>
                <button
                    type="button"
                    className="btn btn-primary"
                    onClick={click}
                >
                    Сохранить
                </button>
            </ModalFooter>
        </Modal>
    );

};

const DeviceIcon = ({posX, posY, color, click }) => {
    const style = {
        top: posY,
        left: posX,
    };

    return (
        <svg className="deviceRect" xmlns="http://www.w3.org/2000/svg" width="19" height="19" style={style} onClick={click}>
            <rect width="19" height="19" fill={color} stroke="black"  strokeWidth="2" />
        </svg>
    );
};


const FloorsPlan = ({ SiteService, FloorsImages }) => {
    const [activeImage, setActiveImage] = useState(0);
    const [isUpdated, setIsUpdated] = useState(false);
    const [devices, setDevices] = useState([]);
    const [isOpenModal, setIsOpenModal] = useState(false);
    const [currentDevice, setCurrentDevice] = useState({});
    useEffect(() => {
        if (!isUpdated) {
            SiteService.GetDevices().then(result=>{
                setDevices(result);
                setIsUpdated(true);
            });
        }
    });
    const DeviceOnClick = (id) =>{
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
        return(<DeviceIcon posX={e.posX} posY={e.posY} color ={e.isInUse===1?e.color:"grey"} key={e.deviceId} click={()=> DeviceOnClick(e.deviceId)} />);
    })

    const handleChange = (event) => {
        setCurrentDevice({
            ...currentDevice,
            [event.target.name]:event.target.value,
        });
    };
    return (
        <div className="unselectable">
            <ul className="nav nav-tabs FloorTabs justify-content-center">
                {floortab}
            </ul>
            <div className="imageContainer">
                {Devices}
                <img src={FloorsImages[activeImage].href} className="floorImg" alt="..." />
            </div>
            <DeviceWindow
                device={currentDevice}
                isOpen={isOpenModal}
                click={()=> setIsOpenModal(!isOpenModal)}
                change={(event) => handleChange(event)}
            />
        </div> 
        );
};

const mapStateToPropsFloorsPlan = ({ FloorsImages }) => {
    return { FloorsImages };
};

export default WithSiteService(connect(mapStateToPropsFloorsPlan)(FloorsPlan));
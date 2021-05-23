import React, { useState, useEffect } from 'react';
import { connect } from "react-redux";
import {WithSiteService} from "../components/hoc";
import Modal, {ModalHeader, ModalFooter, ModalBody} from "../components/Modal";

const DeviceWindow = ({modal, click}) =>{
    return(
        <Modal isOpen={modal}>
            <ModalHeader>
                <h3>This is modal header</h3>
                <button
                    type="button"
                    className="close"
                    aria-label="Close"
                    onClick={click}
                >
                    <span aria-hidden="true">&times;</span>
                </button>
            </ModalHeader>
            <ModalBody>
                <p>This is modal body</p>
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
                    Save changes
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
    const [isUpdated, setisUpdated] = useState(false);
    const [devices, setDevices] = useState([]);
    const [modal, setModal] = useState(false);
    useEffect(() => {
        if (!isUpdated) {
            SiteService.GetDevices().then(result=>{
                setDevices(result);
                setisUpdated(true);
            });
        }
    });
    const floortab = FloorsImages.map((element, index) => {
        const className = index === activeImage ? "FloorTabItem nav-link active" : "FloorTabItem nav-link";

        return (
            <li className="nav-item" onClick={() => setActiveImage(index)} key={element.id}>
                <span className={className} > {element.name}</span>
            </li>
            );
    });
    const Devices = devices.filter(e=>(e.isEnabled && e.levelId===(activeImage+1))).map(e =>{
        return(<DeviceIcon posX={e.posX} posY={e.posY} color ={e.isInUse===1?e.color:"grey"} key={e.deviceId} click={()=> setModal(!modal)} />);
    })

    return (
        <div className="unselectable">
            <ul className="nav nav-tabs FloorTabs justify-content-center">
                {floortab}
            </ul>
            <div className="imageContainer">
                {Devices}
                <img src={FloorsImages[activeImage].href} className="floorImg" alt="..." />
            </div>
            <DeviceWindow modal={modal} click={()=> setModal(!modal)}/>
        </div> 
        );
};

const mapStateToPropsFloorsPlan = ({ FloorsImages }) => {
    return { FloorsImages };
};

export default WithSiteService(connect(mapStateToPropsFloorsPlan)(FloorsPlan));
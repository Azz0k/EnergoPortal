import React, { useState } from 'react';
import { connect } from "react-redux";

const DeviceIcon = ({posX, posY, color }) => {
    const style = {
        top: posX,
        left: posY,
    };
    return (
        <svg className="deviceRect" xmlns="http://www.w3.org/2000/svg" width="20" height="20" style={style}>
            <rect width="20" height="20" fill={color} stroke="black"  stroke-width="2" />
        </svg>
    );
};


const FloorsPlan = ({ FloorsImages }) => {
    const [activeImage, setActiveImage] = useState(0);
    const floortab = FloorsImages.map((element, index) => {
        const className = index === activeImage ? "nav-link active" : "nav-link";
        return (
            <li class="nav-item" onClick={() => setActiveImage(index)} key={element.id}>
                <a className={className} aria-current="page" href="javascript:void(0);">{element.name}</a>
            </li>
            );
    });
    
    return (
        <div>
            <ul className="nav nav-tabs FloorTabs justify-content-center">
                {floortab}
            </ul>
            <div className="imageContainer">
                <img src={FloorsImages[activeImage].href} className="floorImg" alt="..." />
            </div>
        </div> 
        );
};

const mapStatetoPropsFloorsPlan = ({ FloorsImages }) => {
    return { FloorsImages };
};

export default connect(mapStatetoPropsFloorsPlan)(FloorsPlan);
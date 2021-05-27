import React from "react";

const InputTextField = ({ value, onchange, name, placeholder="", readonly = false}) =>{
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
const InputCheckBox= ({ value, onchange, name, placeholder, readonly = false}) =>{
    return(
        <div className="form-check mb-3 DeviceInput col-sm">
            <input
                type="checkbox"
                className="form-check-input"
                name={name}
                id = {name}
                checked={!!value}
                disabled={readonly}
                onChange={onchange}
            />
            <label className="form-check-label" htmlFor={name}>
                {placeholder}
            </label>
        </div>
    );
};

const InputSelectField = ({ value, onchange, name,  readonly = false}) =>{
    const typeValues = ["Компьютер", "Принтер", "WiFi", "Другое", "Камера", "Регистратор"];
    const options = typeValues.map(el=> {
        if (el===value)  return (<option key = {el} value={el} selected>{el}</option>)
        else return (<option key = {el} value={el}>{el}</option>);
    });
    return(
        <div className="mb-3 DeviceInput col-sm">
            <select className="form-select" onChange={onchange} disabled={readonly} name={name}>
                {options}
            </select>
        </div>
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
export {InputSelectField, InputCheckBox, InputTextField, DeviceIcon};
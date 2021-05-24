import React, {useState, useEffect} from "react";

export const ModalHeader = props => {
    return <div className="modal-header">{props.children}</div>;
};

export const ModalBody = props => {
    return <div className="modal-body">{props.children}</div>;
};

export const ModalFooter = props => {
    return <div className="modal-footer">{props.children}</div>;
};

const Modal = ({isOpen, children}) => {
    const [modalShow, setModalShow] = useState('');
    const [display, setDisplay] = useState('none');
    const OpenModal = () => {
      setModalShow('show');
      setDisplay('block');
    };
    const CloseModal = () => {
        setModalShow('');
        setDisplay('none');
    };
    useEffect(()=>{
        isOpen?OpenModal():CloseModal();
    });
    const style ={
        display,
    };
    return(
        <div className={'modal fade ' + modalShow}
             tabIndex="-1"
             role="dialog"
             aria-hidden="true"
             style={ style }>
            <div className="modal-dialog" role="document">
                <div className="modal-content">{children}</div>
            </div>
        </div>
    );
};

export default Modal;
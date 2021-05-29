import React from 'react';
import { connect } from "react-redux";

const DropDownMenuItem = ({ menu }) => {
    let result = menu.filter(el => (el.parentId == undefined));
    result = result.map(el => {
        let temp = null;
        if (el.subId.length > 0) {
            const subMenuItems = menu.filter(e => el.subId.includes(e.id)).map(e => <SubMenuItem href={e.href} name={e.name} key={e.id} />);
            temp = (<ul className="dropdown-menu" aria-labelledby="navbarDropdown" >
                { subMenuItems}
            </ul >);
        }
        return (<MenuItem href={el.href} key={el.id} name={el.name} sub={temp} />)
    });

    return (
        <React.Fragment>
            {result}
        </React.Fragment>
    );

};

const MenuItem = ({ href, name, sub }) => {
    return (
        <React.Fragment>
            <li className="nav-item dropdown">
                <a className="nav-link" href={href} >{name}</a>
                {sub}
            </li>
        </React.Fragment>
    );
};

const SubMenuItem = ({href, name}) => {
    return(
      <React.Fragment>
          <li><a className="dropdown-item" href={href}>{name}</a></li>
      </React.Fragment>
    );
};

const NavBar = ({ MainMenu }) => {

    return (
        <React.Fragment>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <a className="navbar-brand" href="#">
                        <img src="/img/energo2.png" alt="" width="30" height="24" />
                    </a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">

                            <DropDownMenuItem menu = {MainMenu.horisontalMenu} />

                        </ul>

                    </div>
                </div>
            </nav>
        </React.Fragment>
    );
};
const mapStatetoPropsNavBar = ({ MainMenu }) => {
    return { MainMenu };
};

export default connect(mapStatetoPropsNavBar)(NavBar);
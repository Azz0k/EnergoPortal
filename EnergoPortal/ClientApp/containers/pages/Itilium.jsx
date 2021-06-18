import React, { useState, useEffect } from 'react';
import { connect } from "react-redux";
import {WithSiteService} from "../components/hoc";

const Itilium = ({SiteService}) => {
  const [response, setResponse] = useState('');
  useEffect(()=>{
    SiteService.TestSoap().then(result=>{
      setResponse(result);
    });
  });
  return (
      <div>Тест</div>
  );
};

const mapStateToProps = ({  CurrentUser }) => {
  return { CurrentUser };
};
export default WithSiteService(connect(mapStateToProps)(Itilium));
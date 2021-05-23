import React from "react";
import {ServiceConsumer} from "../service-context";

const WithSiteService = Wrapped => {
  return props => {
    return(
        <ServiceConsumer>
            {SiteService =>{
                return (
                    <Wrapped
                        {...props}
                        SiteService={SiteService}
                        />
                );
            }
            }
        </ServiceConsumer>
    );
  };
};

export default WithSiteService;

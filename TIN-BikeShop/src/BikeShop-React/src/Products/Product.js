import React from "react";
import { BrowserRouter as Router, Switch, Route, Link, useRouteMatch, useParams } from "react-router-dom";

function Product() {
    let { shopId } = useParams();
    return (
        <h3>Requested shopId : {shopId}</h3>
    );
}
export default Product;

import React from "react";
import Login from "./Login/Login";
import Register from "./Register/Register";

const Auth = (props) => {
	return (
		<div>
			{props.page === true ? (
				<Login setAuth={props.setAuth} />
			) : (
				<Register />
			)}
		</div>
	);
};

export default Auth;

import React from "react";
import classes from "./../Header.module.css";
import { AiOutlineLogin, AiOutlineUserAdd } from "react-icons/ai";
const AuthButton = (props) => {
	return (
		<div className={classes.loginRegister}>
			<div className={classes.login}>
				<button
					onClick={(e) => {
						props.pageChange(true);
					}}
				>
					<AiOutlineLogin className={classes.loginIcon} />
					Log In
				</button>
			</div>

			<div className={classes.register}>
				<button
					onClick={(e) => {
						props.pageChange(false);
					}}
				>
					<AiOutlineUserAdd className={classes.registerIcon} />
					Register
				</button>
			</div>
		</div>
	);
};

export default AuthButton;

import React from "react";
import classes from "./Header.module.css";
import {
	AiOutlineMenu,
	AiOutlineLogin,
	AiFillMessage,
	AiOutlineUserAdd,
} from "react-icons/ai";
import AuthButton from "./AuthButton/AuthButton";

const Header = (props) => {
	return (
		<div className={classes.header}>
			<div className={classes.menuLogo}>
				<AiOutlineMenu className={classes.menuButton} />
				<div className={classes.logo}>
					<AiFillMessage className={classes.iconMessanger} />
					<h1>Messanger</h1>
				</div>
			</div>

			{props.auth === false ? (
				<AuthButton pageChange={props.pageChange} />
			) : (
				""
			)}
		</div>
	);
};

export default Header;

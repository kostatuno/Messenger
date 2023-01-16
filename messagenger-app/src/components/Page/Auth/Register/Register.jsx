import React from "react";
import classes from "./Register.module.css";
import { AiOutlineLock } from "react-icons/ai";

const Register = () => {
	return (
		<div className={classes.register}>
			<div className={classes.titleRegister}>
				<AiOutlineLock className={classes.iconTitle} />
				<h1>Register</h1>
			</div>
			<form>
				<input
					type="text"
					className={classes.username}
					placeholder="Username | smerch88"
				/>
				<input
					type="email"
					className={classes.email}
					placeholder="Email | example@gmail.com"
				/>
				<input
					type="password"
					className={classes.password}
					placeholder="Password | qwerty123"
				/>

				<button onClick={(e) => e.preventDefault()}>Register</button>
			</form>
		</div>
	);
};

export default Register;

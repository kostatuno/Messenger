import React, { useState } from "react";
import classes from "./Login.module.css";
import { AiOutlineLock } from "react-icons/ai";

const Login = (props) => {
	const loginToDialog = (e) => {
		e.preventDefault();
		props.setAuth(true);
	};

	//Login state
	const [login, setLogin] = useState("");
	const [password, setPassword] = useState("");

	return (
		<div className={classes.login}>
			<div className={classes.titleLogin}>
				<AiOutlineLock className={classes.iconTitle} />
				<h1>Login</h1>
			</div>
			<form>
				<input
					type="text"
					value={login}
					onChange={(e) => setLogin(e.preventDefault())}
					className={classes.username}
					placeholder="Username | smerch88"
				/>

				<input
					type="password"
					value={password}
					onChange={(e) => setPassword(e.preventDefault())}
					className={classes.password}
					placeholder="Password | qwerty123"
				/>

				<button onClick={loginToDialog}>Login</button>
			</form>
		</div>
	);
};

export default Login;

import React from "react";
import classes from "./MessageItem.module.css";

const MessageItem = () => {
	return (
		<div className={classes.message}>
			<div className={classes.messageInfo}>
				<img
					src="https://avatars.githubusercontent.com/u/88688235?v=4"
					alt=""
					width={"40px"}
					height={"40px"}
				/>
				<p className={classes.whoSend}>Ivan</p>
			</div>

			<div className={classes.messageBackground}>
				<p className={classes.messageText}>Lorem ipsum dolor yet</p>
			</div>
		</div>
	);
};

export default MessageItem;

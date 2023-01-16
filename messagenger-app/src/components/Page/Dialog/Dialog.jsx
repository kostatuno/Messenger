import React from "react";
import classes from "./Dialog.module.css";
import { AiOutlineSend } from "react-icons/ai";
import MessageItem from "./MessageItem/MessageItem";

const Dialog = (props) => {
	return (
		<div className={classes.dialogSection}>
			<div className={classes.infoAboutDialog}>
				<img
					src="https://avatars.githubusercontent.com/u/88688235?v=4"
					alt="avatar"
					width={"50px"}
					height={"50px"}
				/>
				<div className={classes.nameStatus}>
					<div className={classes.name}>
						<h1>Ivan</h1>
					</div>
					<div className={classes.status}>
						<div className={classes.onlineStatus}></div>
						<p>online</p>
					</div>
				</div>
			</div>

			<div className={classes.dialog}>
				<MessageItem />
			</div>

			<div className={classes.sendMessage}>
				<input
					type="text"
					className={classes.addMessage}
					placeholder="Type a message..."
				/>
				<button className={classes.sendMessageBtn}>
					<AiOutlineSend className={classes.iconSendMessageBtn} />
				</button>
			</div>
		</div>
	);
};

export default Dialog;

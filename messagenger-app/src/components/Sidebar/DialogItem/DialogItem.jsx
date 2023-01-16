import React from "react";
import classes from "./DialogItem.module.css";

const DialogItem = (props) => {
	return (
		<div className={classes.dialogItem}>
			<div className={classes.avatar}>
				<img
					src={props.photoUrl}
					alt="user"
					width={"50px"}
					height={"50px"}
				/>
			</div>
			<div className={classes.nameLastMessage}>
				<div className={classes.name}>
					<p>{props.name}</p>
				</div>
				<div className={classes.lastMessage}>
					<p>{props.lastMessage}</p>
				</div>
			</div>
		</div>
	);
};

export default DialogItem;

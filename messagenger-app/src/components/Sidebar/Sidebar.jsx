import React from "react";
import DialogItem from "./DialogItem/DialogItem";
import classes from "./Sidebar.module.css";

const Sidebar = () => {
	return (
		<div className={classes.sidebar}>
			<div className={classes.choosePage}>
				<ul>
					<li className={classes.active}>
						<a href="#">Chat</a>
					</li>

					<li>
						<a href="#">Friends</a>
					</li>
				</ul>
			</div>

			<div className={classes.dialogsList}>
				<DialogItem
					name="Oleg"
					lastMessage="Are you here?"
					photoUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/7/71/Calico_tabby_cat_-_Savannah.jpg/1200px-Calico_tabby_cat_-_Savannah.jpg"
				/>
			</div>
		</div>
	);
};

export default Sidebar;

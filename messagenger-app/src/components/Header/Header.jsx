import React from "react";
import classes from "./Header.module.css";
import { AiOutlineMenu, AiOutlineSearch, AiFillMessage } from "react-icons/ai";

const Header = () => {
	return (
		<div className={classes.header}>
			<div className={classes.menuLogo}>
				<AiOutlineMenu className={classes.menuButton} />
				<div className={classes.logo}>
					<AiFillMessage className={classes.iconMessanger} />
					<h1>Messanger</h1>
				</div>
			</div>

			<div className={classes.search}>
				<div className={classes.searchIconDiv}>
					<AiOutlineSearch className={classes.searchIcon} />
				</div>
				<input
					type="text"
					className={classes.searchInput}
					placeholder="Search"
				/>
			</div>
		</div>
	);
};

export default Header;

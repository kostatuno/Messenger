import "./App.css";
import Header from "./components/Header/Header";
import Sidebar from "./components/Sidebar/Sidebar";
import Dialog from "./components/Page/Dialog/Dialog";
import { useState } from "react";
import Auth from "./components/Page/Auth/Auth";

function App() {
	const [auth, setAuth] = useState(false);
	//Change login and register page
	const [page, setPage] = useState(true);

	return (
		<div className="App">
			<Header auth={auth} pageChange={setPage} />

			<div className="sidebarContentApp">
				{auth === true ? <Sidebar /> : ""}
				{auth === true ? (
					<Dialog />
				) : (
					<Auth setAuth={setAuth} page={page} />
				)}
			</div>
		</div>
	);
}

export default App;

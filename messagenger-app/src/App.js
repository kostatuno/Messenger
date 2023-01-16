import "./App.css";
import Header from "./components/Header/Header";
import Sidebar from "./components/Sidebar/Sidebar";

function App() {
	return (
		<div className="App">
			<Header />

			<Sidebar />

			<div className="content"></div>
		</div>
	);
}

export default App;

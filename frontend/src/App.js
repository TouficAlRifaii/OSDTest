import "./App.css";
import LoginPage from "./Components/LoginPage";
import Navbar from "./Components/Navbar";
import QuoteBar from "./Components/QuoteBar";
import CardHeader from "./Components/CardHeader";
import {
  faBars,
  faListCheck,
  faSquareCheck,
} from "@fortawesome/free-solid-svg-icons";
import axios from "axios";

function App() {
  return (
    <div className="App">
      <LoginPage />
      {/* <Navbar />
      <QuoteBar />
      <div className="card-container">
        <CardHeader title={"To Do"} icon={faBars} iconColor={"purple"} />
        <CardHeader title={"Doing"} icon={faListCheck} iconColor={"orange"} />
        <CardHeader title={"Done"} icon={faSquareCheck} iconColor={"green"}/>
      </div>*/}
    </div>
  );
}

export default App;

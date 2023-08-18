import Form from "./form";
import Man from "../assests/Man.svg";
import Woman from "../assests/Woman.svg";
import "../Styles/LoginPage.css";


const LoginPage = () => {
  return (
    <div>
      <div className="landing box">
        <img
          className="login_logo"
          src={require("../assests/Logo.png")}
          alt="Logo"
        ></img>
        <div className="bottom-images">
          <img className="woman" src={Woman} alt="Logo"></img>
          <img className="man" src={Man} alt="man"></img>
        </div>
      </div>
      <Form />
    </div>
  );
};

export default LoginPage;

import React, { useState } from "react";
import axios from "axios";

const Form = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    const data = {
      email: email,
      password: password,
    };

    try {
      const response = await axios.post(
        "https://localhost:7269/api/login",
        data
      );

      console.log(response);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="form box">
      <div className="form-content">
        <div className="form-header">
          <h1>Time To Work!</h1>
        </div>
        <form>
          <div className="form-group">
            <label htmlFor="Email">Email</label>
            <input
              type="email"
              id="Email"
              name="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label htmlFor="Password">Password</label>
            <input
              type="password"
              id="Password"
              name="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>

          <button type="submit" className="btn" onClick={handleSubmit}>
            Sign In
          </button>
        </form>
      </div>
    </div>
  );
};

export default Form;

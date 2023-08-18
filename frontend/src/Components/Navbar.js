import React, { useState } from "react";
import "../Styles/Navbar.css";
import Circle from "../assests/Circle.svg";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCirclePlus,
  faSearch,
  faUser,
  faRightFromBracket
} from "@fortawesome/free-solid-svg-icons";

const Navbar = () => {
  const [showSearchBar, setShowSearchBar] = useState(false);
  const [showAddItemTooltip, setShowAddItemTooltip] = useState(false);
  const [showAvatarBubble, setShowAvatarBubble] = useState(false);

  const handleAvatarClick = () => {
    setShowAvatarBubble(!showAvatarBubble);
  };

  return (
    <nav className="navbar">
      <div className="navbar-left">
        {/* Logo */}
        <img className="logo" src={require("../assests/Logo.png")} alt="logo" />
      </div>
      <div className="navbar-right">
        <div
          className="search-bar"
          onMouseEnter={() => setShowSearchBar(true)}
          onMouseLeave={() => setShowSearchBar(false)}
        >
          {/* Search icon */}
          {showSearchBar ? (
            <input
              type="text"
              placeholder="What are you looking for?"
              autoFocus
              onBlur={() => setShowSearchBar(false)}
            />
          ) : (
            <FontAwesomeIcon className="search-icon" icon={faSearch} />
          )}
        </div>
        <div className="icon">
          {/* Plus icon for creating new items */}
          <div
            className="add-item-button"
            onMouseEnter={() => setShowAddItemTooltip(true)}
            onMouseLeave={() => setShowAddItemTooltip(false)}
          >
            <FontAwesomeIcon className="plus-icon" icon={faCirclePlus} />
            {showAddItemTooltip && <div className="tooltip">Add Item</div>}
          </div>
        </div>
        <div className="icon">
          {/* Avatar icon */}
          <div className="avatar-icon" onClick={handleAvatarClick}>
            <FontAwesomeIcon icon={faUser} />
            {showAvatarBubble && (
              <div className="avatar-bubble">
                <div className="avatar-icon-small">
                  <FontAwesomeIcon icon={faUser} />
                </div>
                <div className="email">user@example.com</div>
                <button className="logout-button">Logout <FontAwesomeIcon icon={faRightFromBracket} /></button>
              </div>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;

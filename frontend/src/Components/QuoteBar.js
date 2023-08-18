import { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faClose, faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import "../Styles/QuoteBar.css";
const QuoteBar = () => {
  const [quoteVisible, setQuoteVisible] = useState(false);

  const toggleQuoteVisibility = () => {
    setQuoteVisible(!quoteVisible);
  };
  return (
    <div className="quote-bar">
      {!quoteVisible && (
        <button className="quote-bar-icon" onClick={toggleQuoteVisibility}>
          <FontAwesomeIcon icon={faInfoCircle} />
        </button>
      )}
      {quoteVisible && (
        <div className="hidden-quote-bar">
          <p>'Anyting that can go wrong, will go wrong!' </p>
          <FontAwesomeIcon
            className="close-quote"
            icon={faClose}
            onClick={toggleQuoteVisibility}
          />
        </div>
      )}
    </div>
  );
};

export default QuoteBar;

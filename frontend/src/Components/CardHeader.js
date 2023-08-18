import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../Styles/CardHeader.css"

const CardHeader = ({ title, icon, iconColor}) => {
    return (
        <div className="card-header">
            <h3>
                <FontAwesomeIcon icon={icon} style={{color: iconColor}} className="header-icon" />
                {title}
            </h3>
        </div>
    );
}

export default CardHeader;
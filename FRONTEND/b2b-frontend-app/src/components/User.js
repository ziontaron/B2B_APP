import "../stylesheets/User.css";
import { ImUserTie } from "react-icons/im";

function User({ closeSession, userName }) {
  const _logout = (e) => {
    closeSession("", "", "");
  };
  return (
    <>
      {userName ? (
        <div className='user-nav-container'>
          <ImUserTie className='icon' />
          <div className='user-info'>
            <p>{userName}</p>
            <button onClick={_logout}>Logout</button>
          </div>
        </div>
      ) : (
        <div></div>
      )}
    </>
  );
}

export default User;

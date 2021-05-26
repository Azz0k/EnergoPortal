const updateCurrentUser =({accessToken, userName, role})=> {
  return {
      type:"updateCurrentUser",
      payload:{accessToken, userName, role},
  }
};

export {
  updateCurrentUser,
};
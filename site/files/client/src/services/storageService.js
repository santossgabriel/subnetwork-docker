const keys = {
  USER: 'USER'
}

const getUser = () => JSON.parse(localStorage.getItem(keys.USER))

const setUser = user => localStorage.setItem(keys.USER, JSON.stringify(user))

export default {
  setUser,
  getUser
}
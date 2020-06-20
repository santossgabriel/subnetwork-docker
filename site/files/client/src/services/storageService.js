const keys = {
  USER: 'USER'
}

const getUser = () => JSON.parse(localStorage.getItem(keys.USER))

const setUser = user => user ? localStorage.setItem(keys.USER, JSON.stringify(user)) : localStorage.removeItem(keys.USER)

export default {
  setUser,
  getUser
}
export const onlyNumbers = str => str && /^[0-9]{0,}$/.test(str)

export const mixedAlphaLowerUpperCase = str => str && /^[a-zA-Z]{0,}$/.test(str)

export const mixedAlphaNumericLowerUpperCase = str => str && /^[a-zA-Z0-9]{0,}$/.test(str)

const addLeftZero = val => (val > 9 ? '' : '0') + val

export const toDateFormat = p => {
  if (!p)
    return p
  const date = new Date(p)
  if (date.toString() === 'Invalid Date')
    return p
  const year = String(date.getFullYear()).substring(2, 4)
  const month = addLeftZero(date.getMonth() + 1)
  const day = addLeftZero(date.getDate())
  const min = addLeftZero(date.getMinutes())
  const hours = addLeftZero(date.getHours())
  return `${day}/${month}/${year} ${hours}:${min}`
}
import { mixedAlphaLowerUpperCase, onlyNumbers, mixedAlphaNumericLowerUpperCase } from './string'

const messages = [
  ['Instantly', 'Instantly', 'Instantly', 'Instantly', '4 secs', '40 secs', '6 mins', '1 hour', '11 hours', '4 days', '46 days', '1 year', '12 years'],
  ['Instantly', '8 secs', '5 mins', '3 hours', '4 days', '169 days', '16 years', '600 years'],
  ['3 secs', '3 mins', '3 hours', '10 days', '153 days', '1 year', '106 years'],
  ['10 secs', '13 mins', '17 hours', '57 days', '12 years', '928 years']
],
  RED = '#F00',
  YELLOW = '#FF0',
  GREEN = '#0F0'

export const howLongToCrackPassword = password => {
  let result = { message: null, color: null }
  let index = password ? password.length - 5 : -1
  if (index < 0) {
    result.message = 'Instantly'
    result.color = RED
  } else if (onlyNumbers(password)) {
    result.message = messages[0][index]
    result.color = index === 10 ? YELLOW : index > 10 ? GREEN : RED
  } else if (mixedAlphaLowerUpperCase(password)) {
    result.message = messages[1][index]
    result.color = index === 5 ? YELLOW : index > 5 ? GREEN : RED
  } else if (mixedAlphaNumericLowerUpperCase(password)) {
    result.message = messages[2][index]
    result.color = index === 4 ? YELLOW : index > 4 ? GREEN : RED
  } else {
    result.message = messages[3][index]
    result.color = index === 3 ? YELLOW : index > 3 ? GREEN : RED
  }

  result.message = result.message || 'Too many years'

  return result
}
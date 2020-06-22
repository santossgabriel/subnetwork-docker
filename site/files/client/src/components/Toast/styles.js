import styled from 'styled-components'

export const ContainerGlobalToast = styled.div`
  background-color: ${({ error }) => error ? '#f2c0c566' : '#c0f2c5'};
  color: ${({ error }) => error ? '#721c24' : '#1c7224'};
  border: ${({ show, error }) => show ? error ? 'solid 1px #ee7c88' : 'solid 1px #7cee88' : 'none'};
  border-radius: 4px;
  position: fixed;
  transition: 200ms;
  width: ${({ show }) => show ? '400px' : '0px'};
  overflow-x: hidden;
  color: #888;
  right: 16px;
  top: 80px;
  font-family: Arial, Helvetica, sans-serif;
  span {
    color: ${({ error }) => error ? '#721c24' : '#1c7224'};
  }
`

export const ContainerContent = styled.div`
  width: 400px; 
  display: flex;
  flexDirection: row;
`

export const ContainerText = styled.div`
  margin: 20px 6px;
`
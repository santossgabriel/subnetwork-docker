import React from 'react'
import { useSelector } from 'react-redux'
import { toastTypes } from '../../utils'
import { ContainerContent, ContainerGlobalToast, ContainerText } from './styles'

export function Toast() {

  const { message, type } = useSelector(state => state.toastState)

  return (
    <ContainerGlobalToast show={!!message} error={type === toastTypes.ERROR} >
      <ContainerContent>
        <ContainerText>
          <span>{message}</span>
        </ContainerText>
      </ContainerContent>
    </ContainerGlobalToast>
  )
}
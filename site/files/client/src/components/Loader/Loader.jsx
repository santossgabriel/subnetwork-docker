import React from 'react'
import { useSelector } from 'react-redux'

import { Container } from './styles'

export function Loader() {


    const loading = useSelector(state => state.appState.loading)

    return (
        loading ?
            <Container>
                <div className="lds-spinner">
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                </div>
            </Container>
            : null
    )
}
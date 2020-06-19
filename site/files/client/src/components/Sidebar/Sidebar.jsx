import React from 'react'
import { ROUTES } from '../../utils'
import { Container, MenuItem } from './styles'

export function Sidebar() {
    return (
        <Container>
            {ROUTES.map((r, i) => <MenuItem key={i + ''} to={r.route}>{r.title}</MenuItem>)}
            {/* <MenuItem exact="true" to={ROUTES.HOME}>Home</MenuItem> */}
        </Container>
    )
}
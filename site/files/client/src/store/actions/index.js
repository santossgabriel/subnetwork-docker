
export const CommandActionsTypes = {
    BANNER_GRABBING_START: 'BANNER_GRABBING_START',
    BANNER_GRABBING_DATA: 'BANNER_GRABBING_DATA',
    BANNER_GRABBING_END: 'BANNER_GRABBING_END',
    NETWORK_SWEEPING_START: 'NETWORK_SWEEPING_START',
    NETWORK_SWEEPING_DATA: 'NETWORK_SWEEPING_DATA',
    NETWORK_SWEEPING_END: 'NETWORK_SWEEPING_END',
}

export const ToastActionsTypes = {
    ERROR: 'TOAST_ERROR',
    SUCCESS: 'TOAST_SUCCESS',
    HIDE: 'TOAST_HIDE'
}

export const toastSuccess = message => ({ payload: message, type: ToastActionsTypes.SUCCESS })
export const toastError = message => ({ payload: message, type: ToastActionsTypes.ERROR })
export const toastHide = () => ({ payload: '', type: ToastActionsTypes.HIDE })

export const mapSocketActions = (socket, dispatch) => {
    for (let key in CommandActionsTypes) {
        socket.on(key, data => {
            dispatch({ type: CommandActionsTypes[key], payload: data })
        })
    }

    socket.on('SOCKET_SUCCESS', data => {
        dispatch(toastSuccess(data))
        setTimeout(() => dispatch(toastHide()), 2000)
    })

    socket.on('SOCKET_ERROR', data => {
        dispatch(toastError(data))
        setTimeout(() => dispatch(toastHide()), 2000)
    })
}
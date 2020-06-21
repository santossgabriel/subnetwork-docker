export const AppActionsTypes = {
    USER_CHANGED: 'USER_CHANGED',
    LOADER_CHANGED: 'LOADER_CHANGED',
}

export const ToastActionsTypes = {
    ERROR: 'TOAST_ERROR',
    SUCCESS: 'TOAST_SUCCESS',
    HIDE: 'TOAST_HIDE'
}

export const userChanged = user => ({ payload: user, type: AppActionsTypes.USER_CHANGED })

export const showLoader = show => ({ payload: true, type: AppActionsTypes.LOADER_CHANGED })
export const hideLoader = show => ({ payload: false, type: AppActionsTypes.LOADER_CHANGED })

export const toastSuccess = message => ({ payload: message, type: ToastActionsTypes.SUCCESS })
export const toastError = message => ({ payload: message, type: ToastActionsTypes.ERROR })
export const toastHide = () => ({ payload: '', type: ToastActionsTypes.HIDE })
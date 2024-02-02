
interface ImportMetaEnv {
    readonly VITE_LOGOUT_ENDPOINT: string
    readonly VITE_GOOGLE_LOGIN_ENDPOINT: string
    readonly VITE_LOGIN_ENDPOINT: string
    readonly VITE_REGISTER_ENDPOINT: string
    readonly VITE_BASE_URL: string
    readonly VITE_GOOGLE_CLIENT_ID: string
    readonly VITE_CREATE_CAUSE_ENDPOINT: string
    readonly VITE_GET_ALL_CAUSES_ENDPOINT: string
    readonly VITE_GET_CAUSE_BY_ID_ENDPOINT: string
    readonly VITE_GET_USER_ENDPOINT: string
    readonly VITE_UPDATE_USER_ENDPOINT: string

}

interface ImportMeta {
    readonly env: ImportMetaEnv
}
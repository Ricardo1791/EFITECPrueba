export class LoginDTO{
    username: string;
    password: string;

    /**
     *
     */
    constructor() {
        this.username = null;
        this.password = null;
    }
}

export interface User {
    username: string;
    token: string;
    person: string;
}
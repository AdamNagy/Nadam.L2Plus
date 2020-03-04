export interface LoginRequestModel {
    email: string;
    password: string;
}
export interface RegisterRequestModel {
	email: string;
	password: string;
}

export interface AccountModel {
	password: string;
	token: string;
	firstName: string;
	lastName: string;
	email: string;
	id: string;
}

export interface  LoginResponseModel {
	success: boolean;
	errorMessage: string;
	account: AccountModel;
}

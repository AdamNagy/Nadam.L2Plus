export interface LoginRequestModel {
    email: string;
    password: string;
}

export interface UserModel {
	password: string;
	token: string;
	firstName: string;
	lastName: string;
	email: string;
	id: string;
}

export interface RegisterRequestModel {
	email: string;
    password: string;
}

export interface  LoginResponeModel {
	success: boolean;
	errorMessage: string;
	account: UserModel;
}

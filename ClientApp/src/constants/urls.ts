export const BASE_URL =
  process.env.NODE_ENV == "production"
    ? "https://mxstrong.azurewebsites.net"
    : "https://localhost:5001";
export const CHECK_EMAIL_URL = BASE_URL + "/api/auth/emailTaken";
export const REGISTER_URL = BASE_URL + "/api/auth/register";
export const LOGIN_URL = BASE_URL + "/api/auth/login";
export const CURRENT_USER_URL = BASE_URL + "/api/auth/currentUser";
export const LOGOUT_URL = BASE_URL + "/api/auth/logout";
export const FETCH_POSTS_URL = BASE_URL + "/api/posts";
export const FETCH_TOPICS_URL = BASE_URL + "/api/topics";
export const ADD_POST_URL = BASE_URL + "/api/posts";
export const ADD_TOPIC_URL = BASE_URL + "/api/topics";
export const EDIT_POST_URL = BASE_URL + "/api/posts";
export const DELETE_POST_URL = BASE_URL + "/api/posts";
export const FETCH_COMMENTS_URL = BASE_URL + "/api/comments";
export const ADD_COMMENT_URL = BASE_URL + "/api/comments";
export const EDIT_COMMENT_URL = BASE_URL + "/api/comments";
export const DELETE_COMMENT_URL = BASE_URL + "/api/comments";
export const FETCH_GOALS_URL = BASE_URL + "/api/goals";

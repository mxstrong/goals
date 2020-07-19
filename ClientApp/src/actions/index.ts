import {
  UPDATE_USER,
  UPDATE_POSTS,
  UPDATE_TOPICS,
  UPDATE_PROFILE,
} from "./types";
import {
  IUserLoginData,
  IUpdateUserAction,
  IUserProfile,
  IUpdateProfileAction,
  IUpdatePostsAction,
  IPost,
  ITopic,
  IUpdateTopicsAction,
} from "../helpers/types";
import { Dispatch } from "redux";
import {
  LOGIN_URL,
  CURRENT_USER_URL,
  LOGOUT_URL,
  FETCH_POSTS,
  FETCH_TOPICS,
} from "../constants/urls";

function updateUser(user: string): IUpdateUserAction {
  return {
    type: UPDATE_USER,
    user,
  };
}

function updateUserProfile(userProfile: IUserProfile): IUpdateProfileAction {
  return {
    type: UPDATE_PROFILE,
    userProfile,
  };
}

function updatePosts(posts: IPost[]): IUpdatePostsAction {
  return {
    type: UPDATE_POSTS,
    posts,
  };
}

function updateTopics(topics: ITopic[]): IUpdateTopicsAction {
  return {
    type: UPDATE_TOPICS,
    topics,
  };
}

export function loginUser(user: IUserLoginData) {
  return async function (dispatch: Dispatch<IUpdateUserAction>) {
    const response = await fetch(LOGIN_URL, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
    });
    if (response.ok) {
      const data = await response.json();
      const token = data.tokenString;
      dispatch(updateUser(token));
    } else {
      return Promise.reject();
    }
  };
}

export function loadUser(userToken: string) {
  return function (dispatch: Dispatch<IUpdateUserAction>) {
    dispatch(updateUser(userToken));
  };
}

export function loadUserProfile(userToken: string) {
  return async function (dispatch: Dispatch<IUpdateProfileAction>) {
    const response = await fetch(CURRENT_USER_URL, {
      method: "GET",
      headers: {
        Authorization: "Bearer " + userToken,
        "Content-Type": "application/json",
      },
    });
    if (response.ok) {
      const userProfile = await response.json();
      dispatch(updateUserProfile(userProfile));
    }
  };
}

export function logoutUser() {
  return function (
    dispatch: Dispatch<IUpdateUserAction | IUpdateProfileAction>
  ) {
    dispatch(updateUser(""));
    dispatch(updateUserProfile({ id: "", name: "", email: "" }));
  };
}

export function fetchPosts() {
  return async function (dispatch: Dispatch<IUpdatePostsAction>) {
    const response = await fetch(FETCH_POSTS, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });
    const posts: IPost[] = await response.json();
    dispatch(updatePosts(posts));
  };
}

export function fetchTopics() {
  return async function (dispatch: Dispatch<IUpdateTopicsAction>) {
    const response = await fetch(FETCH_TOPICS, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });
    const topics = await response.json();
    dispatch(updateTopics(topics));
  };
}

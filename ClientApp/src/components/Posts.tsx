import React, { useEffect, useState } from "react";
import {
  Typography,
  makeStyles,
  Theme,
  Paper,
  Card,
  CardContent,
  CardActionArea,
  IconButton,
  CardHeader,
  Fab,
  Menu,
  MenuItem,
} from "@material-ui/core";
import AddIcon from "@material-ui/icons/Add";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import { useDispatch, useSelector } from "react-redux";
import { fetchPosts, fetchCurrentPost } from "../actions";
import { AppState } from "../reducers";
import { IPost } from "../helpers/types";
import { Link, useHistory } from "react-router-dom";
import { DELETE_POST_URL } from "../constants/urls";
import { role } from "../constants/roles";

const useStyles = makeStyles((theme: Theme) => ({
  paper: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  card: {
    width: "240px",
    margin: theme.spacing(1),
  },
  menu: {
    boxShadow: "none",
  },
  link: {
    textDecoration: "none",
    color: "#000000",
  },
}));

export default function Posts() {
  const classes = useStyles();
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(fetchPosts());
  }, []);

  const posts = useSelector((state: AppState) => state.posts.posts);
  const userToken = useSelector((state: AppState) => state.auth.user);
  const userProfile = useSelector((state: AppState) => state.auth.userProfile);
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

  function handleClick(event: React.MouseEvent<HTMLButtonElement>) {
    setAnchorEl(event.currentTarget);
  }

  function handleClose() {
    setAnchorEl(null);
  }

  async function handleDelete(id: string) {
    const response = await fetch(DELETE_POST_URL + "/" + id, {
      method: "DELETE",
      headers: {
        Authorization: "Bearer " + userToken,
      },
    });
    if (response.ok) {
      dispatch(fetchPosts());
    }
    handleClose();
  }

  const history = useHistory();

  function handleEdit(post: IPost) {
    dispatch(fetchCurrentPost(post.postId));
    history.push("/posts/edit");
    handleClose();
  }

  return (
    <Paper className={classes.paper}>
      <Typography variant="h3">Posts</Typography>
      {posts.map((post: IPost) => (
        <Card className={classes.card} key={post.postId}>
          <CardHeader
            action={
              userProfile.role === role.admin ||
              userProfile.userId == post.userId ? (
                <React.Fragment>
                  <IconButton aria-label="settings" onClick={handleClick}>
                    <MoreVertIcon />
                  </IconButton>
                  <Menu
                    anchorEl={anchorEl}
                    keepMounted
                    open={Boolean(anchorEl)}
                    onClose={handleClose}
                    className={classes.menu}
                  >
                    <MenuItem onClick={() => handleEdit(post)}>Edit</MenuItem>
                    <MenuItem onClick={() => handleDelete(post.postId)}>
                      Delete
                    </MenuItem>
                  </Menu>
                </React.Fragment>
              ) : (
                ""
              )
            }
            title={post.title}
            subheader={`By ${post.author} 
              Topic: ${post.topic}  
              ${post.createdAt}`}
          />
          <Link to={"/post?id=" + post.postId} className={classes.link}>
            <CardContent>
              <Typography variant="body2">{post.body}...</Typography>
            </CardContent>
          </Link>
        </Card>
      ))}
      <Card>
        <CardActionArea>
          <Link to="/posts/add" component={Fab} color="primary">
            <AddIcon />
          </Link>
        </CardActionArea>
      </Card>
    </Paper>
  );
}

import React from "react";
import {
  makeStyles,
  Paper,
  TextField,
  Button,
  Typography,
} from "@material-ui/core";
import { Link } from "react-router-dom";

const useStyles = makeStyles((theme) => ({
  form: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
  },
  input: {
    width: "80%",
    margin: theme.spacing(1),
  },
  paper: {
    padding: theme.spacing,
    height: "60%",
    flex: "1 0 200px",
  },
  text: {
    textAlign: "center",
    margin: theme.spacing(2),
  },
  button: {
    width: "80%",
  },
}));

export default function Login() {
  const classes = useStyles();
  return (
    <Paper className={classes.paper}>
      <Typography className={classes.text} variant="h3">
        Sign In
      </Typography>
      <form className={classes.form}>
        <TextField className={classes.input} label="Email" variant="outlined" />
        <TextField
          className={classes.input}
          label="Password"
          variant="outlined"
        />
        <Button className={classes.button} variant="contained" color="primary">
          Login
        </Button>
      </form>
      <Typography className={classes.text} variant="body2">
        Not our user yet? <Link to="/register">Register</Link>
      </Typography>
    </Paper>
  );
}
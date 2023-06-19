import { FC, useState } from "react";
import useStyles from "./styles";
import { Box, Button, Container, TextField } from "@mui/material";
import Logo from "../../components/Logo/Logo";
import axios from "axios";
import instance from "../../api/instance";
import { useAuth } from "../../hooks/useAuth";

interface LoginProps {}

const Login: FC<LoginProps> = () => {
  const s = useStyles();
  const { login } = useAuth();
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [incorrect, setIncorrect] = useState(false);

  const handleSubmit = async (event: any) => {
    event.preventDefault();

    try {
      const obj = {
        userID: userName,
        password: password,
      };
      const response = await instance.post("/Auth", obj);
      login({ token: response.data.accessToken });
    } catch (error) {
      setIncorrect(true);
    }
  };

  return (
    <Container component="main" maxWidth="xs" className={s.classes.container}>
      <Box className={s.classes.box}>
        <Box>
          <Logo link="/" />
        </Box>
        <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="username"
            label="Username"
            name="username"
            autoFocus
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            error={incorrect}
          />
          <TextField
            margin="normal"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            autoComplete="current-password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            error={incorrect}
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign In
          </Button>
        </Box>
      </Box>
    </Container>
  );
};

Login.defaultProps = {};

export default Login;

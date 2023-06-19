import { FC, useState } from "react";
import useStyles from "./styles";
import {
  Box,
  Button,
  Checkbox,
  FormControl,
  FormControlLabel,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";

interface ContactProps {}

const Contact: FC<ContactProps> = () => {
  const s = useStyles();
  const [subject, setSubject] = useState<number>(1);

  const handleSubmit = (event: any) => event.preventDefault();
  return (
    <Box
      component="form"
      onSubmit={handleSubmit}
      noValidate
      className={s.classes.contact}
    >
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6} md={6}>
          <TextField
            margin="normal"
            required
            id="firstName"
            label="First Name"
            name="firstName"
            autoFocus
            fullWidth
          />
        </Grid>
        <Grid item xs={12} sm={6} md={6}>
          <TextField
            margin="normal"
            required
            id="lastName"
            label="Last Name"
            name="lastName"
            fullWidth
          />
        </Grid>
        <Grid item xs={12} sm={6} md={6}>
          <TextField
            type="email"
            margin="normal"
            required
            id="email"
            label="Email"
            name="email"
            fullWidth
          />
        </Grid>
        <Grid item xs={12} sm={6} md={6}>
          <FormControl fullWidth sx={{ mt: "16px" }}>
            <InputLabel id="subject">Subject</InputLabel>
            <Select
              labelId="subject"
              id="subject"
              value={subject}
              label="Subject"
              onChange={(e) => setSubject(e.target.value as any)}
            >
              <MenuItem value={1}>Compliment</MenuItem>
              <MenuItem value={2}>Complaint</MenuItem>
              <MenuItem value={3}>Other</MenuItem>
            </Select>
          </FormControl>
        </Grid>
        <Grid item xs={12} sm={12} md={12}>
          <TextField
            margin="normal"
            required
            id="text"
            label="Text"
            name="text"
            fullWidth
            multiline
            maxRows={2}
          />
        </Grid>
        <Grid item xs={12} sm={12} md={12}>
          <FormControlLabel
            required
            control={<Checkbox size="small" />}
            label="I have read and agree to the privacy policy."
          />
        </Grid>
        <Grid item xs={12} sm={12} md={3}>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Send
          </Button>
        </Grid>
      </Grid>
    </Box>
  );
};

Contact.defaultProps = {};

export default Contact;

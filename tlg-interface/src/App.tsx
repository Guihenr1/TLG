import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
  defer,
} from "react-router-dom";
import { AuthLayout } from "./components/Security/AuthLayout";
import Login from "./pages/Login/Login";
import Feed from "./pages/Feed/Feed";
import Base from "./pages/Base/Base";
import Contact from "./pages/Contact/Contact";

const getUserData = () =>
  new Promise((resolve) => {
    const user = window.localStorage.getItem("user");
    resolve(user);
  });

export const router = createBrowserRouter(
  createRoutesFromElements(
    <Route
      element={<AuthLayout />}
      loader={() => defer({ userPromise: getUserData() })}
    >
      <Route path="/" element={<Login />} />

      <Route element={<Base />}>
        <Route path="/feed" element={<Feed key="feed" wishlist={false} />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/wishlist" element={<Feed key="wishlist" wishlist />} />
      </Route>
    </Route>
  )
);

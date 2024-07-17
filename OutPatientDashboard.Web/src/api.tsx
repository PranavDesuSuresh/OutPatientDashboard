import axios from "axios";

export const getData = async (url: string) => {
  try {
    return await axios.get(url).then((token) => {
      return token.data;
    });
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log("error message : ", error.message);
      return error.message;
    } else {
      console.log("unexpected error: ", error);
      return "unexpected error";
    }
  }
};

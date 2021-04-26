import React, { Component } from 'react';
import axios from 'axios';

export class Home extends Component {
    static displayName = Home.name;

    state = {
        posts: []
    }

    componentDidMount = async () => {
        const { data } = await axios.get("/api/lakewoodscoop/getposts");
        this.setState({ posts: data });
    }

    render() {
        return (
            <div className="container">
                {this.state.posts.map((post, i) => {
                    return (
                        <div key={i} className="well col-md-6 col-md-offset-6 border border-success" style={{ marginTop: 30 }}>
                            <a href={post.titleUrl} target="_blank">{post.title}</a>
                            <img src={post.imageUrl} />
                            <a href={post.titleUrl} style={{ textDecoration: "none" }} className="text-dark" target="_blank">{post.blurb}</a>
                            <br />
                            <a className="text-warning" href={post.commentsUrl} target="_blank">{post.comments}</a>
                        </div>
                    )
                })}
            </div>
        );
    }
}
